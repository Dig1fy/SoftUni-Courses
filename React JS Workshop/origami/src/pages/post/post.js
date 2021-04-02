import React from 'react'
import Title from '../../components/title/title'
import PageLayout from '../../components/layout/layout'
import styles from './post.module.css'
import SubmitButton from '../../components/submitButton/submitButton'

const PostPage = () => {

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
        </PageLayout>
    )
}

export default PostPage