function solve(){
	return function(){
		$.fn.listview = function(data) {
			var templateSource = $('#' + (this.attr('data-template'))).html();
			var template = handlebars.compile(templateSource);
			var len = data.length,
			i;

			for (i = 0; i < len; i+=1) {
				this.append(template(data[i]));
			}

			return this;
		};
	};
}

module.exports = solve;