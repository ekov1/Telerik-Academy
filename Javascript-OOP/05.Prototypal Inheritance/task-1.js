/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
	  * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  *  method removeAttribute(attribute)
*/

/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/

function solve() {
	var domElement = (function () {
		var domElement = {
			init: function(type) {
				this.type = type;
				return this;
			},
			appendChild: function(child) {
				this.children = child;
				return this;
			},
			addAttribute: function(name, value) {
				this.attributes = {name: name, value: value};
				return this;
			},
			removeAttribute: function(attribute) {
				if (!this.attributes[attribute]) {
					throw new Error('The attribute you are attempting to remove is not present!');
				}
				delete this.attributes[attribute];
				return this;
			},

			get innerHTML(){
				var ot = '<', //opening tag
					ct = '>', //closing tag
					result = ot + this.type;

				//place attributes
				var keys = [];
				for (var key in this.attributes) {
					keys.push(key);
				}

				if (keys.length > 0) {
					keys.sort(function(a, b) {
						return b < a;
					});

					var len = keys.length,
						i;

					for (i = 0; i < len; i += 1) {
						result += ' ' + keys[i] + '="' + this.attributes[keys[i]] + '"';
					}
				}

				//closing the opening tag
				result += ct;

				for (var child of this.children) {
					if (typeof(child) === 'string') {
						result += child;
					} else {
						result += child.innerHTML;
					}
				}

				result += this.content;


				result += ot + '/' + this.type + ct;
				return result;
			},

			//content get/set
			get content() {
				return this._content || '';
			},
			set content(content) {
				if (this.children.length === 0) {
					if (typeof(content) !== 'string') {
						throw new Error('Content must be represented as a string!');
					}
					this._content = content;
				}
			},

			//type get/set
			get type() {
				return this._type;
			},
			set type(type) {
				if (type && typeof(type) === 'string') {
					if (/^[A-Z0-9]+$/i.test(type)) {
						this._type = type;
						return;
					}
				}
				throw new Error('Element not recognized!');
			},

			//parent get/set
			get parent() {
				return this._parent;
			},
			set parent(parent) {
				this._parent = parent;
			},

			//children get/set
			get children() {
				return this._children || [];
			},
			set children(child) {
				if (child && child._type) {
					if (child._type) {
						child.parent = this;
					}
				}

				this._children = this._children || [];
				this._children.push(child);
			},

			//attributes get/set
			get attributes() {
				return this._attributes;
			},
			set attributes(attr) {
				if (attr.name === '' || !(/^[A-Z\-0-9]+$/i).test(attr.name)) {
					throw new Error('Invalid attribute name!');
				}

				this._attributes = this._attributes || [];
				this._attributes[attr.name] = attr.value;
			}
		};
		return domElement;
	} ());
	return domElement;
}

module.exports = solve;
