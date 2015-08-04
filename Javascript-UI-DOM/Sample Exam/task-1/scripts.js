function createCalendar(selector, events) {
	var element = document.querySelector(selector);
	var div = document.createElement('div');
	var p = document.createElement('p');
	var pEvent = document.createElement('p');
	var frag = document.createDocumentFragment();
	var days = ['Sat', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
	var selectedDay;

	div.style.border = '1px solid black';
	div.style.float = 'left';
	div.style.width = '10%';
	div.style.height = '160px';
	div.style.padding = '0';
	div.style.margin = '0';

	p.style.backgroundColor = '#CCC';
	p.style.padding = '0';
	p.style.margin = '0';
	p.style.textAlign = 'center';
	p.style.position = 'relative';
	p.style.borderBottom = '1px solid black';

	pEvent.style.padding = '0';
	pEvent.style.paddingTop = '5px';
	pEvent.style.margin = '0';
	pEvent.textAlign = 'left';
	pEvent.position = 'relative';

	for (var i = 0; i < 30; i+=1) {
		var dayContainer = div.cloneNode(true);
		var titleContainer = p.cloneNode(true);
		var eventContainer = pEvent.cloneNode(true);

		titleContainer.innerHTML = days[i%7] + ' ' + (i+1) + ' June 2014';

		if (i%7 === 0) {
			dayContainer.style.clear = 'both';
		}

		events.map(function(event) {
			if (event.date*1 === i) {
				eventContainer.innerHTML = event.hour + ': ' + event.title;
				return;
			}
		});

		dayContainer.appendChild(titleContainer);
		dayContainer.appendChild(eventContainer);
		frag.appendChild(dayContainer);
	}

	element.appendChild(frag);


	element.addEventListener('mouseover', function(e) {
		var t = e.target;
		if (t.firstChild && t.firstChild.style) {
			t.firstChild.style.backgroundColor = '#666';	
		}
	});

	element.addEventListener('mouseout', function(e) {
		var t = e.target;
		if (t.firstChild && t.firstChild.style) {
			t.firstChild.style.backgroundColor = '#CCC';
		}	
	});

	element.addEventListener('click', function(e) {
		var t = e.target.parentElement;

		if (selectedDay && selectedDay.style) {
			selectedDay.style.backgroundColor = 'initial';
		}


		selectedDay = t;
		selectedDay.style.backgroundColor = '#00C';
	});

}