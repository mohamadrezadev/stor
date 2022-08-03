function numCounter(tagId,maxCount,speed){
  var initialNumber = 0;
  function counter(){
      document.getElementById(tagId).innerHTML = initialNumber;
      ++initialNumber;
  }
  var counterDelay = setInterval(counter,speed);
  function totalTime(){
      clearInterval(counterDelay);
  }
  var totalPeriod = speed * (maxCount);  
  setTimeout(totalTime, totalPeriod);
}

numCounter("Projects",44,100);
numCounter("Clients",12,400);
numCounter("Partners",436,10);




$(document).ready(function() {

  var owl = $('.owl-carousel');

  owl.owlCarousel({

    loop: true,

    rtl:true,

    margin: 10,

    navRewind: false,

    responsive: {

      0: {

        items: 1

      },

      550: {

        items: 2

      },

      900: {

        items: 2

      },

      1200: {

        items: 2

      }

    }

  })

})


jQuery(document).ready(function($){
  var offset = 100;
  var speed = 250;
  var duration = 500;
   $(window).scroll(function(){
          if ($(this).scrollTop() < offset) {
     $('.topbutton') .fadeOut(duration);
          } else {
     $('.topbutton') .fadeIn(duration);
          }
      });
$('.topbutton').on('click', function(){
  $('html, body').animate({scrollTop:0}, speed);
  return false;
  });
});


/* ---- rating star ----*/

$(document).ready(function () {

  /* 1. Visualizing things on Hover - See next part for action on click */
  $('#stars li').on('mouseover', function () {
      var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

      // Now highlight all the stars that's not after the current hovered star
      $(this).parent().children('li.star').each(function (e) {
          if (e < onStar) {
              $(this).addClass('hover');
          }
          else {
              $(this).removeClass('hover');
          }
      });

  }).on('mouseout', function () {
      $(this).parent().children('li.star').each(function (e) {
          $(this).removeClass('hover');
      });
  });


  /* 2. Action to perform on click */
  $('#stars li').on('click', function () {
     
      var onStar = parseInt($(this).data('value'), 10); // The star currently selected
      var stars = $(this).parent().children('li.star');

      for (i = 0; i < stars.length; i++) {
          $(stars[i]).removeClass('selected');
      }

      for (i = 0; i < onStar; i++) {
          $(stars[i]).addClass('selected');
      }

     

  });


});


/*----- shopping cart -----*/

$(document).ready(function(){
  update_amounts();
  $('.qty, .price').on('keyup keypress blur change', function(e) {
    update_amounts();
  });
});
function update_amounts(){
var sum = 0.0;
    $('#myTable > tbody  > tr').each(function() {
    var qty = $(this).find('.qty').val();
      var price = $(this).find('.price').val();
      var amount = (qty*price)
      sum+=amount;
      $(this).find('.amount').text(''+amount);
    });
$('.total').text(sum);
}



//----------------for quantity-increment-or-decrement-------
var incrementQty;
var decrementQty;
var plusBtn  = $(".cart-qty-plus");
var minusBtn = $(".cart-qty-minus");
var incrementQty = plusBtn.click(function() {
var $n = $(this)
  .parent(".button-container")
  .find(".qty");
$n.val(Number($n.val())+1 );
update_amounts();
});

var decrementQty = minusBtn.click(function() {
  var $n = $(this)
  .parent(".button-container")
  .find(".qty");
var QtyVal = Number($n.val());
if (QtyVal > 0) {
  $n.val(QtyVal-1);
}
update_amounts();
});
