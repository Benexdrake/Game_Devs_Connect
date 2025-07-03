import style from '@/styles/layout.module.css'
import Navbar from "./nav/navbar";

export default function Layout(props:any)
{
    const {children} = props;

    return (
        <div className={style.main}>
            <nav className={style.sidebar}>
                <Navbar/>
            </nav>
            <div className={style.child}>
                {children}
            </div>
        </div>
    )
}