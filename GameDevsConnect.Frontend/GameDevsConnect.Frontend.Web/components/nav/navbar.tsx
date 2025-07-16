import styles from '@/styles/navbar/navbar.module.css'
import NavButton from "./nav_button";
import { signOut, useSession } from 'next-auth/react';
import { IUser } from '@/interfaces/user';
import NavButtonUser from './nav_button_user';

export default function Navbar() 
{
  const {data:session} = useSession();
  const user = session?.user as IUser;

    return (
        <div className={styles.main}>
            <div className={styles.nav}>
                <NavButton icon="fa-solid fa-house" path="/" />
                <NavButton icon="fa-solid fa-bell" path="/" />
                <NavButton icon="fa-solid fa-magnifying-glass" path="/" />
                <NavButton icon="fa-solid fa-envelope" path="/" />
                <NavButtonUser user={user}/>
                <button onClick={() => signOut()}>Logout</button>    
            </div>
        </div>
    )
}