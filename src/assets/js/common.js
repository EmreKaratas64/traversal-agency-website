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