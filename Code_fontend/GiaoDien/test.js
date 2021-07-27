function clickedButton(btn, event) {
    document.getElementById('img').src = btn.getAttribute('data-src');
}

function bindClick(btn) {
    btn.addEventListener('click', clickedButton.bind(null, btn));
}

// Setup click handler(s) when content is loaded
document.addEventListener("DOMContentLoaded", function() {
    Array.from(document.querySelectorAll('#thumb_img > button'))
        .forEach(bindClick));
});