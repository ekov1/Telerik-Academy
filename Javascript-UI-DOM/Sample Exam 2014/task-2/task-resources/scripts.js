/* globals $ */
$.fn.gallery = function (cols) {
	cols = cols || 4;
	this.addClass('gallery');

	var $galleryList = $('.gallery-list'),
	$selected = $('.selected'),
	$imageContainers = $galleryList.find('.image-container'),
	$bg,
	$currentImage = $('#current-image'),
	$previousImage = $('#previous-image'),
	$nextImage = $('#next-image');
	$images = $('.image-container').find('img');

	$selected.hide();

	$imageContainers.each(function(index) {
		var $this = $(this);

		if (index%cols === 0) {
			$this.addClass('clearfix');
		}
	});

	$galleryList.on('click', function(e) {
		$selected.show();
		if (!$bg) {
			$bg = ($('<div />').addClass('disabled-background')).appendTo($galleryList);
		}
		$galleryList.addClass('blurred');

		var $tar = $(e.target);
		var data = ($tar.attr('data-info')) * 1;
		var currentIndex = data;
		changeImages(currentIndex);
	});

	$selected.on('click', function(e) {
		var $this = $(this);

		if ($(e.target).attr('id') === 'current-image') {
			$selected.hide();
			$bg.removeClass('disabled-background');
			$galleryList.removeClass('blurred');
		} else if ($(e.target).attr('id') === 'previous-image') {
			changeImages(($currentImage.attr('data-info')*1)-1);
		} else if ($(e.target).attr('id') === 'next-image') {
			changeImages(($currentImage.attr('data-info')*1)+1);
		}
	});

	function changeImages(currentIndex) {
		var nextIndex;
		var prevIndex;

		if (currentIndex === $images.length) {
			nextIndex = 1;
			prevIndex = currentIndex - 1;
		} else if (currentIndex === 1) {
			nextIndex = currentIndex+1;
			prevIndex = $images.length;		
		} else {
			nextIndex = currentIndex + 1;
			prevIndex = currentIndex - 1;
		}

		$currentImage.attr('src', $images.eq(currentIndex-1).attr('src'));
		$currentImage.attr('data-info', currentIndex);
		if ($currentImage.attr('data-info')*1 > 12) {
			$currentImage.attr('data-info', '1');
		} else if ($currentImage.attr('data-info')*1 < 1) {
			$currentImage.attr('data-info', '12');
		}
		$previousImage.attr('src', $images.eq(prevIndex-1).attr('src'));
		$nextImage.attr('src', $images.eq(nextIndex-1).attr('src'));
	}

	return this;
};