/* globals $ */
$.fn.gallery = function (cols) {
	cols = cols || 4;
	this.addClass('gallery');

	var $galleryList = $('.gallery-list'),
	$selected = $('.selected'),
	$imageContainers = $galleryList.find('.image-container'),
	$bg;

	$selected.hide();

	$imageContainers.each(function(index) {
		var $this = $(this);

		if (index%cols === 0) {
			$this.addClass('clearfix');
		}
	});

	$galleryList.on('click', function() {
		$selected.show();
		if (!$bg) {
			$bg = ($('<div />').addClass('disabled-background')).appendTo($galleryList);
		}
		$galleryList.addClass('blurred');
	});

	$selected.on('click', function(e) {
		var $this = $(this);

		if ($(e.target).attr('id') === 'current-image') {
			$selected.hide();
			$bg.removeClass('disabled-background');
			$galleryList.removeClass('blurred');
		} else if ($(e.target).attr('id') === 'previous-image') {

		} else if ($(e.target).attr('id') === 'next-image') {

		}
	});

	$imageContainers.on('click', function() {

	});

	return this;
};