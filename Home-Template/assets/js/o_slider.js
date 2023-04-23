const csliderButtons = document.querySelectorAll('.pag');
const chomeSliders = document.querySelectorAll('.col-12');

var cindex = 1;
var cinterval;
cotoSlide();

var cslider = function (cindex) {
    csliderButtons.forEach((sliderButton) => {
        sliderButton.classList.remove('active');
    });
    csliderButtons[cindex].classList.add('active');

    chomeSliders.forEach((videoSlider) => {
        videoSlider.style.transform = 'translateX(-' + (100 * cindex) + '%)';
    });
}

csliderButtons.forEach((sliderButton, i) => {
    sliderButton.addEventListener('click', () => {
        cindex = i;
        cslider(cindex);
    });
});

function cotoSlide() {
    cinterval = setInterval(function () {
        if (cindex == 4) {
            cindex = 0;
        }
        cslider(cindex);
        cindex++;
    }, 5000);
}

const csliderNavigation = document.querySelector('.ex-row');
const cpagSlider = document.querySelector('.pag-slider');
csliderNavigation.addEventListener('mouseenter', function () {
    clearInterval(cinterval);
});
csliderNavigation.addEventListener('mouseleave', function () {
    cotoSlide();
});
cpagSlider.addEventListener('mouseenter', function () {
    clearInterval(cinterval);
});
cpagSlider.addEventListener('mouseleave', function () {
    cotoSlide();
});