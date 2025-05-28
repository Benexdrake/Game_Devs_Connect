export type CommentType =
{
    id:number;
    message:string;
    fileId:number;
    parentId:number;
    ownerId:string;
    created:string;
    deleted:boolean;
}