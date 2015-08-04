function solve() {
	return function(selector){

		dropDownList(selector);

		function dropDownList(element) {
			var $select = $(element).css('display', 'none'),
			$divDropdownList = $('<div />').addClass('dropdown-list'),
			$divOptionsContainer = $('<div />').addClass('options-container'),
			$divCurrent = $('<div />').addClass('current'),
			$selectOptions = $select.find('option');

			$select.appendTo($divDropdownList);
			$divCurrent.html('Select a value').appendTo($divDropdownList);
			$divOptionsContainer.css('position', 'absolute').css('display', 'none').appendTo($divDropdownList);

			$selectOptions.each(function(index) {
				var $this = $(this);
				$select.attr('value', $this.attr('value'));

				var $divDropdownItem = $('<div />');
					
					$divDropdownItem
						.addClass('dropdown-item')
						.attr('data-value', $this.attr('value'))
						.html($this.html())
						.on('click', function() {
							$divCurrent.html($this.html())
								.attr('data-value', $this.attr('value'));
							$divOptionsContainer.css('display', 'none');
						})
						.appendTo($divOptionsContainer);
			});

			$divCurrent.on('click', function() {
				$divOptionsContainer.toggle();
				$divCurrent.html('Select a value');
			});

			$('body').append($divDropdownList);
		}
	};
}
	module.exports = solve;