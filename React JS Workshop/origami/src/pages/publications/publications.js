import React from 'react'
import Title from '../../components/title/title'
import PageLayout from '../../components/layout/layout'
import styles from './publications.module.css'
import SubmitButton from '../../components/submitButton/submitButton'
import Posts from '../../components/posts/posts'
import UserContext from '../../Context'

const PublicationsPage = () => {
const context = UserContext
console.log(context);


   const submitHandler = (e) => {
        e.preventDefault();
    }

    return (
        <PageLayout>
            <form onSubmit={(e)=>submitHandler(e)}>
                <Title title="Share your thoughts" />
                <div className={styles.container}>
                    <textarea className={styles.textarea}></textarea>
                    <div>
                        <SubmitButton buttonValue={"Submit"} />
                    </div>
                </div>
            </form>

            <Posts length={3}/>
        </PageLayout>
    )
}

export default PublicationsPage