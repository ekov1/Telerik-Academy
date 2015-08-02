/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

  */
  function solve() {
    return function (selector) {
      

      if (typeof selector !== 'string') {
        throw new Error('Invalid selector');      
      }
      
      var $element = $(selector);
      if(!$element.length){
        throw new Error();
      }

      var $btns = $element.find('.button');

      $btns.html('hide');

      function handler() {
        var $btn = $(this),
        $ctnt = $btn.next();


        while(!($ctnt.hasClass('content'))) {
          if ($ctnt.hasClass('button')) {
            break;
          }
          $ctnt = $ctnt.next();
        }

        if ($ctnt.hasClass('button')) {
          return;
        }

        if ($ctnt.css('display') === 'none') {
          $ctnt.css('display', '');
          $btn.html('hide');
        } else {
          $ctnt.css('display', 'none');
          $btn.html('show');
        }
      }

      $element.on('click', '.button', handler);
    };
  };

  module.exports = solve;