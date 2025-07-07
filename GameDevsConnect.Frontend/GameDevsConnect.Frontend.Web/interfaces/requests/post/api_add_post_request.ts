import { IPost } from "@/interfaces/post";
import { ITag } from "@/interfaces/tag";

export interface IUpsertPostRequest
{
    post:IPost;
    tags:ITag[];
}