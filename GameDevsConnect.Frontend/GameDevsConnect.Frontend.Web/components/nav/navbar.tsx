import styles from '@/styles/navbar/navbar.module.css'
import NavButton from "./nav_button";

export default function Navbar() 
{
    return (
        <div className={styles.main}>
        <div className={styles.nav}>
            <NavButton icon="fa-solid fa-house" path="/" />
            <NavButton icon="fa-solid fa-bell" path="/" />
            <NavButton icon="fa-solid fa-magnifying-glass" path="/" />
            <NavButton icon="fa-solid fa-envelope" path="/" />
            
        </div>
        </div>
    )
}