const SearchFocus = () => {
    const search: HTMLElement | null = document.querySelector(".search");
    if (search == null) return;
    search.classList.add("show");
}
const SearchFocusOut = () => {
    const target: HTMLElement | null = document.querySelector(".search");
    if (target == null) return;
    target.classList.remove("show");
}

const SearchController = async (e: Event) => {
    const query: string = (e.target as HTMLInputElement).value;
    const [books, authors, users] = await Promise.all([
        SearchBooks(query),
        SearchAuthors(query),
        SearchUsers(query)
    ]);
    RenderBooks(books);
    RenderAuthors(authors);
    RenderUsers(users)
}


const SearchBooks = async (query : string) : Promise<Book[] | null> => {
    const fetchData: Response = await fetch(`https://localhost:7051/api/Books/search/${query}`);
    if (fetchData.ok) return await fetchData.json();
    else return null;
}
const SearchUsers = async (query: string) : Promise<User[] | null> => {
    const fetchData: Response = await fetch(`https://localhost:7051/api/Users/search/${query}`);
    if (fetchData.ok) return await fetchData.json();
    else return null;
};
const SearchAuthors = async (query: string) : Promise<Author[] | null>  => {
    const fetchData: Response = await fetch(`https://localhost:7051/api/Authors/search/${query}`);
    if (fetchData.ok) return await fetchData.json();
    else return null;
} 


const RenderUsers = (users : User[] | null) => {
    const resultsHTML: HTMLElement | null = document.querySelector(".search__results--users");
    if (resultsHTML == null) return;
    resultsHTML.innerHTML = "";
    if (users == null) return;
    resultsHTML?.insertAdjacentHTML("beforeend", '<h2 class="search__header" > Users </h2>')
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
                    </a>`
        );
    }
}

const RenderAuthors = (authors: Author[] | null) => {
    const resultsHTML: HTMLElement | null = document.querySelector(".search__results--authors");
    if (resultsHTML == null) return;
    resultsHTML.innerHTML = "";
    if (authors == null) return;
    resultsHTML?.insertAdjacentHTML("beforeend", '<h2 class="search__header" > Authors </h2>')
    for (const author of authors) {
        resultsHTML.insertAdjacentHTML("beforeend",
            `<a href="%"  class="search__result">
                        <img src="${ author.authorImage == null ? "Images/avatar.png" : author.authorImage }" class="result__image" />
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
                    </a>`
        );
    }
}

const RenderBooks = async (books: Book[] | null) => {
    const resultsHTML: HTMLElement | null = document.querySelector(".search__results--books");
    if (resultsHTML == null) return;
    resultsHTML.innerHTML = "";
    if (books == null) return;
    resultsHTML?.insertAdjacentHTML("beforeend", '<h2 class="search__header" > Books </h2>')
    for (const book of books) {
        document.querySelector(".search__results--books")?.insertAdjacentHTML("beforeend",
            `<a href="%" class="search__result">
                        <img src="${ book.bookCover == null ? "Images/avatar.png" : book.bookCover }" class="result__image" />
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
                    </a>`
        );
    }
}

interface User {
    userId: number,
    userNick: string,
    userImage: string,
    userWantRead: number,
    userReviews: number,
    userFollowers: number
}
interface Book {
    bookId: number,
    bookTitle: string,
    authorName: string,
    authorSurname: string,
    averateRate: number,
    bookCover: string,
    wantsToRead: number
}
interface Author {
    authorId: number,
    authorName: string,
    authorSurname: string,
    authorImage: string,
    bookCreated: number
}
document.querySelector(".header__search")?.addEventListener("focus", SearchFocus);
document.querySelector(".header__button--close")?.addEventListener("click", SearchFocusOut);
document.querySelector(".search")?.addEventListener("click", SearchFocusOut);
document.querySelector(".header__search")?.addEventListener('keyup', SearchController);
window.addEventListener("wheel", HideHeaderNav);