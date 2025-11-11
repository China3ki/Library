"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var _a, _b, _c, _d;
const SearchFocus = () => {
    const search = document.querySelector(".search");
    if (search == null)
        return;
    search.classList.add("show");
};
const SearchFocusOut = () => {
    const target = document.querySelector(".search");
    if (target == null)
        return;
    target.classList.remove("show");
};
const SearchController = (e) => __awaiter(void 0, void 0, void 0, function* () {
    const query = e.target.value;
    const [books, authors, users] = yield Promise.all([
        SearchBooks(query),
        SearchAuthors(query),
        SearchUsers(query)
    ]);
    RenderBooks(books);
    RenderAuthors(authors);
    RenderUsers(users);
});
const SearchBooks = (query) => __awaiter(void 0, void 0, void 0, function* () {
    const fetchData = yield fetch(`https://localhost:7051/api/Books/search/${query}`);
    if (fetchData.ok)
        return yield fetchData.json();
    else
        return null;
});
const SearchUsers = (query) => __awaiter(void 0, void 0, void 0, function* () {
    const fetchData = yield fetch(`https://localhost:7051/api/Users/search/${query}`);
    if (fetchData.ok)
        return yield fetchData.json();
    else
        return null;
});
const SearchAuthors = (query) => __awaiter(void 0, void 0, void 0, function* () {
    const fetchData = yield fetch(`https://localhost:7051/api/Authors/search/${query}`);
    if (fetchData.ok)
        return yield fetchData.json();
    else
        return null;
});
const RenderUsers = (users) => {
    const resultsHTML = document.querySelector(".search__results--users");
    if (resultsHTML == null)
        return;
    resultsHTML.innerHTML = "";
    if (users == null)
        return;
    resultsHTML === null || resultsHTML === void 0 ? void 0 : resultsHTML.insertAdjacentHTML("beforeend", '<h2 class="search__header" > Users </h2>');
    for (const user of users) {
        resultsHTML.insertAdjacentHTML("beforeend", ` 
                <a href="%"  class="search__result user">
                        <img src="${user.userImage == null ? "Images/avatar.png" : user.userImage}" class="result__image" />
                        <div class="result__info">
                            <span class="result__title">${user.userNick}</span>
                            <div class="result__bottom">
                                <div class="result__stats">
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">book</span>
                                        <span class="result__rating">${user.userWantRead}</span>
                                    </div>
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">Reviews</span>
                                        <span class="result__rating">${user.userReviews}</span>
                                    </div>
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">visibility</span>
                                        <span class="result__rating">${user.userFollowers}</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>`);
    }
};
const RenderAuthors = (authors) => {
    const resultsHTML = document.querySelector(".search__results--authors");
    if (resultsHTML == null)
        return;
    resultsHTML.innerHTML = "";
    if (authors == null)
        return;
    resultsHTML === null || resultsHTML === void 0 ? void 0 : resultsHTML.insertAdjacentHTML("beforeend", '<h2 class="search__header" > Authors </h2>');
    for (const author of authors) {
        resultsHTML.insertAdjacentHTML("beforeend", `<a href="%"  class="search__result">
                        <img src="${author.authorImage == null ? "Images/avatar.png" : author.authorImage}" class="result__image" />
                        <div class="result__info">
                            <span class="result__title">${author.authorName} ${author.authorSurname}</span>
                            <div class="result__bottom">
                                <div class="result__stats">
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">book_2</span>
                                        <span class="result__rating">${author.bookCreated}</span>
                                    </div>
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">visibility</span>
                                        <span class="result__rating">10</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>`);
    }
};
const RenderBooks = (books) => __awaiter(void 0, void 0, void 0, function* () {
    var _a;
    const resultsHTML = document.querySelector(".search__results--books");
    if (resultsHTML == null)
        return;
    resultsHTML.innerHTML = "";
    if (books == null)
        return;
    resultsHTML === null || resultsHTML === void 0 ? void 0 : resultsHTML.insertAdjacentHTML("beforeend", '<h2 class="search__header" > Books </h2>');
    for (const book of books) {
        (_a = document.querySelector(".search__results--books")) === null || _a === void 0 ? void 0 : _a.insertAdjacentHTML("beforeend", `<a href="%" class="search__result">
                        <img src="${book.bookCover == null ? "Images/avatar.png" : book.bookCover}" class="result__image" />
                        <div class="result__info">
                            <span class="result__title">${book.bookTitle}</span>
                            <div class="result__bottom">
                                <div class="result__stats">
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">star</span>
                                        <span class="result__rating">${book.averateRate == null ? 0 : book.averateRate}</span>
                                    </div>
                                    <div class="result__stat">
                                        <span class="material-symbols-outlined result__icon">book</span>
                                        <span class="result__rating">${book.wantsToRead}</span>
                                    </div>
                                </div>
                                <span class="result__author">${book.authorName} ${book.authorSurname}</span>
                            </div>
                        </div>
                    </a>`);
    }
});
(_a = document.querySelector(".header__search")) === null || _a === void 0 ? void 0 : _a.addEventListener("focus", SearchFocus);
(_b = document.querySelector(".header__button--close")) === null || _b === void 0 ? void 0 : _b.addEventListener("click", SearchFocusOut);
(_c = document.querySelector(".search")) === null || _c === void 0 ? void 0 : _c.addEventListener("click", SearchFocusOut);
(_d = document.querySelector(".header__search")) === null || _d === void 0 ? void 0 : _d.addEventListener('keyup', SearchController);
//# sourceMappingURL=Search.js.map