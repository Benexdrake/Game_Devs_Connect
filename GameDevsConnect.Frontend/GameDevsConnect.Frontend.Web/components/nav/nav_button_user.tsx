import Link from "next/link";
import styles from '@/styles/navbar/navbar.module.css'


export default function NavButtonUser(props:any)
{
    const {user} = props;

    return (    
        <Link href={`/profile/${user.id}`}>
            <div className={styles.nav_item}>
                <img src={user?.avatar} alt="" />
            </div>
        </Link>
    )
}