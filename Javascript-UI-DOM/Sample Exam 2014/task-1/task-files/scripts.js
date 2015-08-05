function createImagesPreviewer(selector, items) {
	var container = document.querySelector(selector);
	var headerDiv = document.createElement('div');
	var div = document.createElement('div');
	var img = document.createElement('img');
	var selectedImageContainer = document.createElement('div');
	var imageStrip = document.createElement('div');
	var imageStripContainer = document.createElement('div');
	var filter = document.createElement('input');

	img.style.height = '150px';
	img.style.width = '200px';

	filter.style.width = '200px';

	headerDiv.style.fontSize = '16px';
	headerDiv.style.textAlign = 'center';

	selectedImageContainer.style.float = 'left';
	selectedImageContainer.style.width = '30%';
	selectedImageContainer.style.textAlign = 'center';
	selectedImageContainer.className = 'image-preview';

	// main image container

	var selectedImageHeader = headerDiv.cloneNode('true');
	selectedImageHeader.style.fontSize = '24px';
	selectedImageHeader.innerHTML = items[0].title;

	var selectedImg = img.cloneNode('true');
	selectedImg.style.height = '400px';
	selectedImg.style.width = '400px';
	selectedImg.src = items[0].url;

	selectedImageContainer.appendChild(selectedImageHeader);
	selectedImageContainer.appendChild(selectedImg);

	// filter and side image strip

	imageStripContainer.style.float = 'left';
	imageStrip.style.height = '500px';
	imageStrip.style.overflow = 'scroll';

	imageStrip.addEventListener('click', function(e) {
		var target = e.target;
		var text = target.previousSibling.innerHTML;
		console.log(target);
		console.log(text);

		selectedImg.src = target.src;
		selectedImageHeader.innerHTML = text;
	});

	var filterHeader = headerDiv.cloneNode(true);
	filterHeader.innerHTML = 'Filter';

	var i,
	len = items.length;

	for (i = 0; i < len; i+=1) {
		var currentDiv = div.cloneNode(true);
		currentDiv.className = 'image-container';
		var currentHeader = headerDiv.cloneNode(true);
		var currentImg = img.cloneNode(true);

		currentImg.src = items[i].url;
		currentHeader.innerHTML = items[i].title;

		currentDiv.appendChild(currentHeader);
		currentDiv.appendChild(currentImg);
		imageStrip.appendChild(currentDiv);
	}


	imageStripContainer.appendChild(filterHeader);
	imageStripContainer.appendChild(filter);
	imageStripContainer.appendChild(imageStrip);

	container.appendChild(selectedImageContainer);
	container.appendChild(imageStripContainer);

}