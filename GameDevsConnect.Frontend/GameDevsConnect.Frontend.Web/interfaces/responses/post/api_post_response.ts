import { ITag } from "@/interfaces/tag";
import { IAPIResponse } from "../api_response";
import { IUser } from "@/interfaces/user";
import { IPost } from "@/interfaces/post";
import { IFile } from "@/interfaces/file";

export interface IAPIPostResponse extends IAPIResponse
{
    post:IPost;
    files:IFile[];
    questCount:number;
    tags: ITag[] | null;
    projectTitle:string;
    owner:IUser;
    comments:number;
    likes:number;
}