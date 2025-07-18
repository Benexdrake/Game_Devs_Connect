import styles from '@/styles/navbar/navbar.module.css'
import NavButton from "./nav_button";
import { signOut, useSession } from 'next-auth/react';
import { IUser } from '@/interfaces/user';
import NavButtonUser from './nav_button_user';
import { useState } from 'react';
import Modal from '../modal/modal';
import AddPost from '../post/add_post';

export default function Navbar() 
{
  const {data:session} = useSession();
  const user = session?.user as IUser;

  const [openModal, setOpenModal] = useState<boolean>();

    return (
        <div className={styles.main}>
            <Modal openModal={openModal} setOpenModal={setOpenModal}>
                <AddPost userId={user.id} postId='' page={false}/>
            </Modal>
            <div className={styles.nav}>
                <NavButton icon="fa-solid fa-house" path="/" />
                <NavButton icon="fa-solid fa-bell" path="/" />
                <NavButton icon="fa-solid fa-magnifying-glass" path="/" />
                <NavButton icon="fa-solid fa-shield" path="/quests" />
                <NavButton icon="fa-solid fa-envelope" path="/" />
                <div onClick={() => setOpenModal(prev => !prev)}>
                    <NavButton icon="fa-solid fa-plus"/>
                </div>
                <NavButtonUser user={user}/>
                <button onClick={() => signOut()}>Logout</button>    
            </div>
        </div>
    )
}