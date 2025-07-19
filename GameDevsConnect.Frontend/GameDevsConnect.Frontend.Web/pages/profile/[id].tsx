import { IProfile } from "@/interfaces/profile";
import { IUser } from "@/interfaces/user";
import { getFullProfileAsync } from "@/services/profile_service";
import { GetServerSidePropsContext } from "next";
import { getSession } from "next-auth/react";

import styles from '@/styles/profile/profile.module.css'
import { getPostIdsByUserIdAsync } from "@/services/post_service";
import ShowPost from "@/components/post/show_post";
import InfiniteScrollPosts from "@/components/infinite_scroll_posts";
import { IAPIProfileFullResponse } from "@/interfaces/responses/profile/api_profile_full_response";

export default function Profile({response, postIds}:{response:IAPIProfileFullResponse, postIds:string[]})
{
    const user = response.user as IUser;
    const profile = response.profile as IProfile;
    const {followerCount, followingCount} = response;

    return (
        <div>
            {response && (
                <div className={styles.main}>
                    <div className={styles.header} style={{backgroundImage: profile.banner || "url('../banner.png')", backgroundPosition:'center', backgroundSize:'cover'}}>
                        <img src={user.avatar} alt=""  className={styles.avatar}/>
                    </div>  
                    <div className={styles.info_block_top}>
                        <div>
                            <div className={styles.username}>
                                <p>{user.username}</p>
                            </div>
                            <div className={styles.follows}>
                                <p><i className="fa-solid fa-users"></i> {followerCount}</p>
                                <p><i className="fa-solid fa-user"></i> {followingCount}</p>
                            </div>
                        </div>
                        <div className={styles.edit_button}>
                            <p>Edit <i className="fa-solid fa-pen-to-square"></i></p>
                        </div>
                    </div>
                    <div className={styles.info_block_bottom}>

                        <div className={styles.profile_text}>
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit.
                                Similique cum quas autem dolor libero modi officiis animi sunt. 
                                Culpa dolor, sapiente unde eius accusantium at veritatis temporibus ex odio quibusdam.
                            </p>
                        </div>
                        <div className={styles.icons}>
                            {!profile.showDiscord && (
                                <a href={profile.discordUrl}>
                                    <i className="fa-brands fa-discord"></i>
                                </a>
                            )}
                            {!profile.showX && (
                                <a href={profile.xUrl}>
                                    <i className="fa-brands fa-x-twitter"></i>
                                </a>
                            )}
                            {!profile.showWebsite && (
                                <a href={profile.websiteUrl}>
                                    <i className="fa-solid fa-globe"></i>
                                </a>
                            )}
                            {!profile.showEmail && (
                                <a href={`mailto:${profile.email}`}>
                                    <i className="fa-solid fa-envelope"></i>
                                </a>
                            )}
                        </div>
                    </div>
                        <div className={styles.menu}>
                            <div className={styles.menu_button}>Posts</div>
                            <div className={styles.menu_button}>Likes</div>
                            <div className={styles.menu_button}>Quests</div>
                            <div className={styles.menu_button}>Projects</div>
                        </div>
                        
                        {postIds && <InfiniteScrollPosts initialIds={postIds} search="" parentId=""/>}
                </div>
            )}
        </div>
    )
}

export async function getServerSideProps(context:GetServerSidePropsContext)
{
    const session = await getSession(context)
    const {id} = context.query;
    
    if(!session)
        return {
            redirect: {
                destination: '/login',
                permanent: false
            }
        }

    if(!id)
        return {
            redirect: {
                destination: '/',
                permanent: false
            }
        }

    // get user
    const response = await getFullProfileAsync(id as string)

    const postsResponse = await getPostIdsByUserIdAsync(id as string);
    
    if(!response.status || !postsResponse.status)
        return {
            redirect: {
                destination: '/',
                permanent: false
            }
        }

    return {
        props: {
            response,
            postIds: postsResponse.ids
        }
    }
    
}