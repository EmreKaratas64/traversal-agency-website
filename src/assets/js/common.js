const bodyTag = document.querySelector('body');
const loader = document.querySelector('.loader');
var notification = document.querySelector('.notification');
window.onload = function () {
    if (loader.classList.contains('active')) {
        loader.classList.remove('active');
    }
    if (bodyTag.classList.contains('locked')) {
        bodyTag.classList.remove('locked');
    }
    setTimeout(() => {
        if (!notification.classList.contains('hidden')) {
            notification.classList.add('hidden');
        }
        setTimeout(() => {
            if (!notification.classList.contains('removed')) {
                notification.classList.add('removed');
            }
        }, 1500);
    }, 10000);
};

const btnBackToTop = document.querySelector('.back-to-top');
const progressBar = document.querySelector('.scroll-progress');
window.addEventListener('scroll', () => {
    btnBackToTop.classList.toggle("active", window.scrollY > 500);

    let progressRatio = window.scrollY / (window.document.body.scrollHeight - window.innerHeight - 1);
    if (progressRatio > 1) {
        progressRatio = 1;
    } else if (progressRatio < 0) {
        progressRatio = 0;
    }
    progressBar.style.height = (progressRatio * 100) + '%';
});
btnBackToTop.addEventListener('click', (e) => {
    e.preventDefault();
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
});


const menu = document.querySelector('.menu');
const menuToggler = document.querySelector('.menu-toggler');
const logo = document.querySelector('.logo');
const logoExpand = document.querySelector('.logo-expand');
const header = document.querySelector('.header');
const right = document.querySelector('.right');
document.querySelector('.menu-toggler').addEventListener('click', () => {
    menu.classList.toggle('hidden');
    menuToggler.classList.toggle('hidden');
    logo.classList.toggle('hidden');
    logoExpand.classList.toggle('hidden');
    header.classList.toggle('hidden');
    right.classList.toggle('active');
});

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

const sliderNavigation = document.querySelector(".slider-navigation");
sliderNavigation.addEventListener("mouseenter", function () {
    clearInterval(interval);
});
sliderNavigation.addEventListener("mouseleave", function () {
    otoSlide();
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