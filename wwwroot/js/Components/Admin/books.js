var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { SortData } from "./sorting.js";
class Books {
    constructor() {
        this.sortData = new SortData();
        this.Sort = (e) => __awaiter(this, void 0, void 0, function* () {
            const sortOptions = this.sortData.GetSortOptions(e.currentTarget);
            if (sortOptions == null)
                return;
            const data = yield this.GetData(sortOptions[0], sortOptions[1]);
            if (data == null)
                return;
            this.RenderData(data);
        });
        this.GetData = (sortBy, sortType) => __awaiter(this, void 0, void 0, function* () {
            const asc = sortType == "Asc" ? false : true;
            const page = parseInt(this.sortData.GetPage());
            const calcStart = (page - 1) * 10;
            const fetchData = yield fetch(`https://localhost:7051/api/Books?start=${calcStart}&sortBy=${sortBy}&limit=10&desc=${asc}`);
            if (fetchData.ok)
                return yield fetchData.json();
            else
                return null;
        });
        this.RenderData = (data) => __awaiter(this, void 0, void 0, function* () {
            const table = document.querySelector(".table");
            if (table == null)
                return;
            this.sortData.RemoveRows();
            for (let i = 1; i < data.length + 1; i++) {
                const row = table.insertRow(i);
                const cell1 = row.insertCell(0);
                const cell2 = row.insertCell(1);
                const cell3 = row.insertCell(2);
                const cell4 = row.insertCell(3);
                const cell5 = row.insertCell(4);
                const cell6 = row.insertCell(5);
                cell1.innerText = `${data[i - 1].bookId}`;
                cell2.innerText = data[i - 1].bookTitle;
                cell3.innerText = data[i - 1].categoryName;
                cell4.innerText = `${data[i - 1].authorName} ${data[i - 1].authorSurname}`;
                cell5.innerText = `${data[i - 1].bookReleaseDate}`;
                cell6.classList.add("table__cell");
                cell6.innerHTML = `<a class = "table__edit" href="/Books/Edit?bookId=${data[i - 1].bookId}">Edit</a>`;
            }
        });
        document.querySelectorAll("[data-sort]").forEach(el => el.addEventListener("click", this.Sort));
    }
}
const books = new Books();
//# sourceMappingURL=books.js.map