const searchForm = document.querySelector('.search-form');
const searchInput = document.querySelector('.search-input');
const searchBtn = document.querySelector('#search-btn');
const cartItem = document.querySelector('.cart-items-container')
const cartBtn = document.querySelector('#cart-btn')
const navbar = document.querySelector('.navbar')
const menuBtn = document.querySelector('#menu-btn')



searchBtn.addEventListener('click', () => {

    searchForm.classList.toggle('active');
    var searchText = searchInput.value.toLowerCase();
    searchPage(searchText);
})

function searchPage(text) {
    var elements = document.getElementsByTagName('p');

    for (var i = 0; i < elements.length; i++) {
        var elementText = elements[i].textContent.toLowerCase();

        if (elementText.includes(text)) {
            elements[i].style.display = 'block';
        } else {
            elements[i].style.display = 'none';
        }
    }
}



menuBtn.addEventListener('click', () => {
    navbar.classList.toggle('active');
    document.addEventListener('click', (e) => {
        if (!e.composedPath().includes(navbar) && !e.composedPath().includes(menuBtn)) {
            navbar.classList.remove('active');
        }
    })
})



