$.fn.tabs = function () {
	this.addClass('tabs-container');

	var $contents = $('.tab-item-content');

	$contents.hide();

	var $current = $('.current');
	$current.show();

	$('strong').on('click', function(e) {
		var tar = e.target;
		console.log(tar);

		$current.removeClass('current');
		$current.children('.tab-item-content').hide();
		$current = $(tar.parentNode).addClass('current');
		$current.children('.tab-item-content').show();
		$current.children('.tab-item-title').show();
	});
};