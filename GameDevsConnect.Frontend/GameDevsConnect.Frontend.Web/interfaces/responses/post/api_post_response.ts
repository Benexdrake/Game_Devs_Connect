import { ITag } from "@/interfaces/tag";
import { IAPIResponse } from "../api_response";
import { IUser } from "@/interfaces/user";
import { IFile } from "@/interfaces/file";
import { IPost } from "@/interfaces/post";

export interface IAPIPostResponse extends IAPIResponse
{
    post:IPost;
    tags: ITag[] | null;
    projectTitle:string;
    owner:IUser;
    file:IFile | null;
}