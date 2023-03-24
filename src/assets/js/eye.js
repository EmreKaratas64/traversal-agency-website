const eyeBtns = document.querySelectorAll('.btn-password-eye');
eyeBtns.forEach((eyeBtn) => {
    eyeBtn.addEventListener('click', () => {
        let inputPassword = eyeBtn.parentElement.children[1];
        if (inputPassword.type === 'password') {
            if (eyeBtn.classList.contains('fa-eye-slash')) {
                inputPassword.type = 'text';
                eyeBtn.classList.remove('fa-eye-slash');
                eyeBtn.classList.add('fa-eye');
            }
        } else {
            if (eyeBtn.classList.contains('fa-eye')) {
                inputPassword.type = 'password';
                eyeBtn.classList.remove('fa-eye');
                eyeBtn.classList.add('fa-eye-slash');
            }
        }
    });
});