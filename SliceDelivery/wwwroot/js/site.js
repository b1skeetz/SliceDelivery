const searchForm = document.querySelector('.search-form');
const searchBtn = document.querySelector('#search-btn');
const cartItem = document.querySelector('.cart-items-container')
const cartBtn = document.querySelector('#cart-btn')
const navbar = document.querySelector('.navbar')
const menuBtn = document.querySelector('#menu-btn')



searchBtn.addEventListener('click', () => {
    searchForm.classList.toggle('active');
    document.addEventListener('click', (e) => {
        if (!e.composedPath().includes(searchBtn) && !e.composedPath().includes(searchForm)) {
            searchForm.classList.remove('active');
        }
    })
})

 



menuBtn.addEventListener('click', () => {
    navbar.classList.toggle('active');
    document.addEventListener('click', (e) => {
        if (!e.composedPath().includes(navbar) && !e.composedPath().includes(menuBtn)) {
            navbar.classList.remove('active');
        }
    })
})





// Создаем объект с текстом на разных языках
const LANGUAGES = {
    en: {
        greeting: 'home',
        about: 'About Us',
        contact: 'Contact Us',
        menu: 'Menu',
        Products: 'Products',
        Review: 'Review',
        blog: 'blog',
        Welcome: 'Welcome',
        Welcome2: ' to our food ordering website! Here you can browse a wide selection of delicious dishes and place your order with ease. Our user-friendly platform makes it simple to customize your meal and choose from a variety of payment options',
        order: 'Order now',
        Pizza_margarita: 'Pizza margarita',
        Big_burger: "Big burger",
        Cheesburger: "Cheesburger",
        Dublburger: "Dublburger",
        check_out: "check out",
        Search: "Search:",
        our: "Our menu",
        Pizza: "Pizza",
        Mini_Pizzas: "6 Mini Pizzas",
        Burgerrrrr: "Burger",
        Mini_Burger: "5 Mini Burgers",
        MIX_Pizza: "2 Mixed Pizzas",
        Pizza2: "Pizza",
        Burgerrrrr2: "Burger",
        Meatball_Burgers: "3 Meatball Burgers",
        our_products: "our products",
        Mini_Burger2: "Mini Burger",
        Bacon_Burger: "Bacon Burger",
        cheese_burger: "cheese burger",
        Double_burger: "Double burger",
    },
    ru: {
        greeting: 'Главная',
        about: 'О нас',
        contact: 'Контакты',
        menu: 'Меню',
        Products: 'Продукция',
        Review: 'Обзор',
        blog: 'Блог',
        Welcome: 'Добро пожаловать ',
        Welcome2: ' на наш сайт для заказа еды! Здесь вы можете просмотреть широкий выбор вкусных блюд и легко разместить свой заказ. Наша удобная платформа позволяет настраивать ваше блюдо и выбирать из различных вариантов оплаты ',
        order: 'Заказывайте прямо сейчас',
        Pizza_margarita: 'Пицца Маргарита',
        Big_burger: "Большой бургер",
        Cheesburger: "Чизбургер ",
        Dublburger: "Двойной Бургер",
        check_out: "Проверить",
        Search: "Поиск:",
        our: "Наш Меню",
        Pizza: "Пицца",
        Mini_Pizzas: "6 Мини пицц",
        Burgerrrrr: "Бургер",
        Mini_Burger: "5 Мини Бургеров",
        MIX_Pizza: "2 Миксовоные Пиццы",
        Pizza2: "Пицца",
        Burgerrrrr2: "Бургер",
        Meatball_Burgers: "3 Бургера с фрикадельками",
        our_products: "наша продукция",
        Mini_Burger2: " Мини Бургер",
        Bacon_Burger: "Бургер с Беконом",
        cheese_burger: "Бургер с сыром",
        Double_burger: "Двойной Бургер",
    },
    kz: {
        greeting: 'Бастық',
        about: 'Біз туралы',
        contact: 'Байланыс',
        menu: 'Меню',
        Products: 'Өнімдер',
        Review: 'Шолу',
        blog: 'Блог',
        Welcome: 'қош келдіңіз',
        Welcome2: 'Мұнда сіз әртүрлі дәмді тағамдарды таңдау және жеткізу мүмкіндігіңіз бар. Біздің пайдаланушылық платформамыз сіздің тамақты настройлауыңызды және төлем тәсілдерін таңдауыңызды жеңілдетеді',
        order: 'тапсырыс беріңіз',
        Pizza_margarita: 'Пицца Маргарита',
        Big_burger: "Үлкен бургер",
        Cheesburger: "Чизбургер",
        Dublburger: "Қос Бургер",
        check_out: "Тексеру",
        Search: "Іздеу:",
        our: "Біздің Меню",
        Pizza: "Пицца",
        Mini_Pizzas: "6 Кішігірім пицца",
        Burgerrrrr: "Бургер",
        Mini_Burger: "5 Кішкентай Бургер",
        MIX_Pizza: "2 Микс Пицца",
        Pizza2: "Пицца",
        Burgerrrrr2: "Бургер",
        Meatball_Burgers: "3 Бургер фрикаделькамен",
        our_products: "Біздің өндіріс",
        Mini_Burger2: "Кішкентай Бургер",
        Bacon_Burger: "Бургер Беконмен",
        cheese_burger: "Бургер ірімшікпен",
        Double_burger: "Екі катлетті бургер",
    },
};

// Определяем язык по умолчанию
let currentLanguage = 'en';

// Функция для обновления текста на странице
function updateText() {
    document.getElementById('greeting').textContent = LANGUAGES[currentLanguage].greeting;
    document.getElementById('about').textContent = LANGUAGES[currentLanguage].about;
    document.getElementById('contact').textContent = LANGUAGES[currentLanguage].contact;
    document.getElementById('menu').textContent = LANGUAGES[currentLanguage].menu;
    document.getElementById('Products').textContent = LANGUAGES[currentLanguage].Products;
    document.getElementById('Review').textContent = LANGUAGES[currentLanguage].Review;
    document.getElementById('blog').textContent = LANGUAGES[currentLanguage].blog;
    document.getElementById('Welcome').textContent = LANGUAGES[currentLanguage].Welcome;
    document.getElementById('Welcome2').textContent = LANGUAGES[currentLanguage].Welcome2;
    document.getElementById('order').textContent = LANGUAGES[currentLanguage].order;
    document.getElementById('Pizza_margarita').textContent = LANGUAGES[currentLanguage].Pizza_margarita;
    document.getElementById('Big_burger').textContent = LANGUAGES[currentLanguage].Big_burger;
    document.getElementById('Cheesburger').textContent = LANGUAGES[currentLanguage].Cheesburger;
    document.getElementById('Dublburger').textContent = LANGUAGES[currentLanguage].Dublburger;
    document.getElementById('check_out').textContent = LANGUAGES[currentLanguage].check_out;
    document.getElementById('Search').textContent = LANGUAGES[currentLanguage].Search;
    document.getElementById('our').textContent = LANGUAGES[currentLanguage].our;
    document.getElementById('Pizza').textContent = LANGUAGES[currentLanguage].Pizza;
    document.getElementById(' Mini_Pizzas').textContent = LANGUAGES[currentLanguage].Mini_Pizzas;
    document.getElementById('Mini_Burger').textContent = LANGUAGES[currentLanguage].Mini_Burger;
    document.getElementById('MIX_Pizza').textContent = LANGUAGES[currentLanguage].MIX_Pizza;
    document.getElementById('Burgerrrrr').textContent = LANGUAGES[currentLanguage].Burgerrrrr;
    document.getElementById('Pizza2').textContent = LANGUAGES[currentLanguage].Pizza2;
    document.getElementById('Burgerrrrr2').textContent = LANGUAGES[currentLanguage].Burgerrrrr2;
    document.getElementById('Meatball_Burgers').textContent = LANGUAGES[currentLanguage].Meatball_Burgers;
    document.getElementById(' our_products').textContent = LANGUAGES[currentLanguage].our_products;
    document.getElementById('Mini_Burger2').textContent = LANGUAGES[currentLanguage].Mini_Burger2;
    document.getElementById('Bacon_Burger').textContent = LANGUAGES[currentLanguage].Bacon_Burger;
    document.getElementById('cheese_burger').textContent = LANGUAGES[currentLanguage].cheese_burger;
    document.getElementById('Double_burger').textContent = LANGUAGES[currentLanguage].Double_burger;
    document.getElementById('Double_burger').textContent = LANGUAGES[currentLanguage].Double_burger;


}


// Обработчики кликов на кнопки
document.getElementById('en-btn').addEventListener('click', function () {
    currentLanguage = 'en';
    updateText();
});

document.getElementById('ru-btn').addEventListener('click', function () {
    currentLanguage = 'ru';
    updateText();
});

document.getElementById('kz-btn').addEventListener('click', function () {
    currentLanguage = 'kz';
    updateText();
});

// Вызываем функцию для установки текста на странице
updateText();


