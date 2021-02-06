import Head from "next/head"
import styles from '../styles/Home.module.css'
import FirstComponent from "./../components/FirstComponent"
export default function Second() {
    return (
        <div className={styles.container}>
            <Head>
                <title>Create Next App</title>
                <link rel="icon" href="/favicon.ico" />
            </Head>

            <main className={styles.main}>
                <h1 className={styles.title}>
                    Second page</h1>
                    <FirstComponent></FirstComponent>
            </main>
        </div>
    )
}