/* globals $ */

function solve() {
  
  return function (selector) {
data = {        
    headers : ['Vendor', 'Model', 'OS'],          
    items : [{          
      col1: 'Nokia',            
      col2: 'Lumia 920',            
      col3: 'Windows Phone'                      
    }, {          
      col1: 'LG',            
      col2: 'Nexus 5',            
      col3: 'Android'                      
    }, {          
      col1: 'Apple',            
      col2: 'iPhone 6',                        
      col3: 'iOS'                      
    }]          
  }; 

    var template = '<table class="items-table">' +
		'<thead>' +
			'<tr>' +
				'<th>#</th>' +
				'{{#each headers}}' +
				'<th>{{this}}</th>' +
				'{{/each}}' +
			'</tr>' +
		'</thead>' +
		'<tbody>' +
			'{{#each items}}' +
				'<tr>' +
				'<td>{{@index}}</td>' +
				'<td>{{this.col1}}</td>' +
				'<td>{{this.col2}}</td>' +
				'<td>{{this.col3}}</td>' +
				'</tr>' +
			'{{/each}}' +
		'</tbody>' +
	'</table>';
    $(selector).html(template);
  };
};

module.exports = solve;
