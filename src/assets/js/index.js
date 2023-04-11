const sliderButtons = document.querySelectorAll('.slider-button');
const homeSliders = document.querySelectorAll('.home-slider');
const homeContents = document.querySelectorAll('.home-content');

var index = 1;
var interval;
otoSlide();

var slider = function (index) {
    sliderButtons.forEach((sliderButton) => {
        sliderButton.classList.remove('active');
    });

    homeSliders.forEach((videoSlider) => {
        videoSlider.classList.remove('active');
    });

    homeContents.forEach((homeContent) => {
        homeContent.classList.remove('active');
    });

    sliderButtons[index].classList.add('active');
    homeSliders[index].classList.add('active');
    homeContents[index].classList.add('active');
}

sliderButtons.forEach((sliderButton, i) => {
    sliderButton.addEventListener('click', () => {
        index = i;
        slider(index);
    });
});

function otoSlide() {
    interval = setInterval(function () {
        if (index == 4) {
            index = 0;
        }
        slider(index);
        index++;
    }, 5000);
}

const sliderNavigation = document.querySelector('.slider-navigation');
sliderNavigation.addEventListener('mouseenter', function () {
    clearInterval(interval);
});
sliderNavigation.addEventListener('mouseleave', function () {
    otoSlide();
});

document.querySelector('.destination-toggler').addEventListener('click', () => {
    document.querySelector('.destination-list').classList.toggle('active');
});

const destinationText = document.querySelector('.destination-text');
document.querySelectorAll('.list-item').forEach(element => {
    element.addEventListener('click', () => {
        document.getElementById('destination' + element.dataset.id).selected = true;
        destinationText.innerText = element.dataset.value;
    });
});

var go_count = true;
$(window).on('scroll', function () {
    if (($('.statistics').offset().top / 2) <= $(window).scrollTop() && go_count) {
        go_count = false;
        $('.count').each(function () {
            $(this).prop('Counter', 0).animate({
                Counter: $(this).text()
            }, {
                duration: 4000,
                easing: 'swing',
                step: function (now) {
                    $(this).text(Math.ceil(now));
                }
            });
        });
    }
})