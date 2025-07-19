import styles from '@/styles/layout.module.css'
import Navbar from "./nav/navbar";
import { useSession } from 'next-auth/react';
import { IUser } from '@/interfaces/user';

export default function Layout({children}:{children:any})
{
    const {data:session} = useSession();

    const user = session?.user as IUser;

    return (
        <div className={styles.main}>
            <nav className={styles.sidebar}>
                {session && <Navbar/>}
            </nav>
            <div className={styles.child}>
                {children}
            </div>
        </div>
    )
}