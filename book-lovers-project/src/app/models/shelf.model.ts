import { BookType } from "./book.model";

export type ShelfType = {
    id: number;
    name: string;
    userId: number;
    books:BookType[];
}