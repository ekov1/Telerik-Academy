function solve() {
  return function (selector, isCaseSensitive) {
  	var element = document.querySelector(selector);

  	if (!isCaseSensitive) {
  		isCaseSensitive = false;
  	}

  	var frag = document.createDocumentFragment();
  	var itemControlDiv = document.createElement('div');
  		itemControlDiv.className += 'items-control';

  	var addElementDiv = document.createElement('div');
  		addElementDiv.className += 'add-controls';
  	var enterTextSpan = document.createElement('label');
  		enterTextSpan.innerHTML = 'Enter Text:';
  		enterTextSpan.htmlFor = 'addInput';
  	var addElementInput = document.createElement('input');	
  		addElementInput.id = 'addInput';
  	var addElementButton = document.createElement('button');
  		addElementButton.className += 'button';
  		addElementButton.innerHTML = 'Add';

  		addElementDiv.appendChild(enterTextSpan);
  		addElementDiv.appendChild(addElementInput);
  		addElementDiv.appendChild(addElementButton);

  	itemControlDiv.appendChild(addElementDiv);


  	var searchElementDiv = document.createElement('div');
  		searchElementDiv.className += 'search-controls';
  	var searchElementSpan = document.createElement('label');
  		searchElementSpan.innerHTML = 'Search:';
  		searchElementSpan.htmlFor = 'searchInput';
  	var searchElementInput = document.createElement('input');
  		searchElementInput.id = 'searchInput';

  		searchElementDiv.appendChild(searchElementSpan);
  		searchElementDiv.appendChild(searchElementInput);

  	itemControlDiv.appendChild(searchElementDiv);

  	var resultElementDiv = document.createElement('div');
  		resultElementDiv.className += 'result-controls';
  	var resultElementItemList = document.createElement('div');
  		resultElementItemList.className += 'items-list';

  		resultElementDiv.appendChild(resultElementItemList);

  	itemControlDiv.appendChild(resultElementDiv);

  	// EVENTS GO BELOW

  	addElementButton.addEventListener('click', function() {
  		if (addElementInput.value) {
  			var entry = document.createElement('div');
  				entry.className += 'list-item';
  			var entrySpan = document.createElement('span');
  				entrySpan.innerHTML = addElementInput.value;
  				addElementInput.value = '';
  			var entryDeleteButton = document.createElement('button');
  				entryDeleteButton.className += 'button';
  				entryDeleteButton.innerHTML = 'X';
  				entryDeleteButton.addEventListener('click', function(e) {
  					var tar = e.target;
  					var parentNode = tar.parentNode;
  					resultElementItemList.removeChild(parentNode);
  				});

  				entry.appendChild(entryDeleteButton);
  				entry.appendChild(entrySpan);

  			resultElementItemList.appendChild(entry);
  		}
  	});

  	searchElementInput.addEventListener('change', function(e) {
  		var text = e.target.value;
  		var listItems = document.getElementsByClassName('list-item');

  		for (var i = 0; i < listItems.length; i+=1) {
  			var currentItem = listItems[i];
  			if (!isCaseSensitive) {
  				if (currentItem.lastElementChild.innerHTML.toLowerCase().indexOf(text.toLowerCase()) >= 0) {
  					currentItem.style.display = 'block';
  				} else {
  					currentItem.style.display = 'none';
  				}
  			} else {
  				if (currentItem.lastElementChild.innerHTML.indexOf(text) >= 0) {
  					currentItem.style.display = 'block';
  				} else {
  					currentItem.style.display = 'none';
  				}
  			}
  		}

  	}, false);

  	frag.appendChild(itemControlDiv);
  	element.appendChild(frag);
  };
}

module.exports = solve;