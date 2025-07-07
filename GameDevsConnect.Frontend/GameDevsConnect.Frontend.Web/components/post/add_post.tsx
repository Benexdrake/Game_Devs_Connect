import { IPost } from "@/interfaces/post";
import { ITag } from "@/interfaces/tag";
import { useState } from "react";

export default function AddPost()
{
    const [newPost, setNewPost] = useState<IPost>();
    const [tags, setTags] = useState<ITag[]>([]);

    // Quests - Falls Quest Post
    
    // File


    return (
        <div>
            INPUT FIELDS and VALIDATION
        </div>
    );
}