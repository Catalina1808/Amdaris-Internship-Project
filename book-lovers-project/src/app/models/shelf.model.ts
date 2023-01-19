import { BookType } from "./book.model";

export type ShelfType = {
    id?: number;
    name: string;
    userId: string;
    books:BookType[];
}