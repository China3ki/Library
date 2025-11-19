import { SortData } from "./sorting.js";
class Authors {
    constructor() {
        document.querySelectorAll("[data-sort]").forEach(el => el.addEventListener("click", this.Sort));
    }
    sortData: SortData = new SortData();
    Sort = async (e: Event) => {
        const sortOptions = this.sortData.GetSortOptions(e.currentTarget as HTMLElement);
        if (sortOptions == null) return;
        const data = await this.GetData(sortOptions[0], sortOptions[1]);
        if (data == null) return;
        this.RenderData(data);
    };

    GetData = async (sortBy: string, sortType: string): Promise<Author[] | null | undefined> => {
        const asc: boolean = sortType == "Asc" ? false : true;
        const page: number | undefined = parseInt(this.sortData.GetPage());
        const calcStart: number = (page - 1) * 10;

        const fetchData: Response = await fetch(`https://localhost:7051/api/Authors?start=${calcStart}&sortBy=${sortBy}&limit=10&desc=${asc}`);
        if (fetchData.ok) return await fetchData.json();
        else return null;
    };

    RenderData = async (data: Author[]) => {
        const table: HTMLTableElement | null = document.querySelector(".table");
        if (table == null) return;
        this.sortData.RemoveRows();
        for (let i = 1; i < data.length + 1; i++) {
            const row = table.insertRow(i);
            const cell1 = row.insertCell(0);
            const cell2 = row.insertCell(1);
            const cell3 = row.insertCell(2);
            const cell4 = row.insertCell(3);
            cell1.innerText = `${data[i - 1].authorId}`;
            cell2.innerText = data[i - 1].authorName;
            cell3.innerText = data[i - 1].authorSurname;
            cell4.classList.add("table__cell");
            cell4.innerHTML = `<a class = "table__edit" href="/Books/Edit?bookId=${data[i - 1].authorId}">Edit</a>`;
        }
    };
}
const author: Authors = new Authors();
interface Author {
    authorId: number,
    authorName: string,
    authorSurname: string
}

