import Link from "next/link";
import styles from '@/styles/navbar/navbar.module.css'


export default function NavButton({icon, path}:{icon:string, path:string})
{
    return (
        <>
            {path !== '' ? (
                <Link href={path}>
                    <div className={styles.nav_item}>
                        <i className={icon}></i>
                    </div>
                </Link>
            )
            :
            (
                <div className={styles.nav_item}>
                    <i className={icon}></i>
                </div>
            )}
        </>
    )
}