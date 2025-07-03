import Link from "next/link";
import styles from '@/styles/navbar/navbar.module.css'


export default function NavButton(props:any)
{
    const {icon, path} = props;

    return (    
        <Link href={path}>
            <div className={styles.nav_item}>
                <i className={icon}></i>
            </div>
        </Link>
    )
}