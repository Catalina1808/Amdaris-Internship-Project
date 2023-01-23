import { AuthorType } from "./author.model";

export type UserType = {
    id: string;
    firstName: string;
    lastName: string;
    userName: string;
    imagePath: string;
    email: string;
    password: string;
    authors: AuthorType[];
}

export type PagedUsersResponse = {
    pageNumber: number,
    pageSize: number,
    totalPages: number,
    data: UserType[],
}