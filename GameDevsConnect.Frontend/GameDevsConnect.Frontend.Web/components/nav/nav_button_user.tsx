import Link from "next/link";
import styles from '@/styles/navbar/navbar.module.css'
import { IUser } from "@/interfaces/user";


export default function NavButtonUser({user}:{user:IUser})
{
    return (    
        <Link href={`/profile/${user.id}`}>
            <div className={styles.nav_item}>
                <img src={user?.avatar} alt="" />
            </div>
        </Link>
    )
}