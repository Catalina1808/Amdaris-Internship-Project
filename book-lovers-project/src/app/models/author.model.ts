import { BookType } from "./book.model";
import { UserType } from "./user.model";

export type AuthorType = {
    id: number;
    name:string;
    image: string;
    description:string;
    books: BookType[];
    followers: UserType[];
}