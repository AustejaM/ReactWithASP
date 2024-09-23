import { useEffect, useState } from "react"
import { IStudent } from "../../interfaces/IStudent";
import { getApi, postApi, putApi } from "../../api";
import { Modal } from "../components/Modal";
import { StudentForm } from "./components/StudentForm";
import { AddStudentForm } from "./components/AddStudentForm";

export default function Students() {
    const [students, setStudents] = useState<IStudent[]>([])
    const [visibleModal, setVisibleModal] = useState<boolean>(false)
    const [editStudent, setEditStudent] = useState<IStudent | undefined>()
    const [addStudentMode, setAddStudentMode] = useState<boolean>(false)


    const getStudents = () => getApi<IStudent[]>('students').then(s => s && setStudents(s))

    const storeStudent = (student: IStudent) => {
        setVisibleModal(false)
        if (student.id) {
            putApi(`students/${student.id}`, student)
                .then(r => getStudents()).then(i => i)
        } else {
            const { id, ...newStudent } = student
            postApi('students', newStudent).then(() => getStudents());
        }
    }
    const editHandler = (student: IStudent) => {
        setEditStudent(student)
        setVisibleModal(true)
        setAddStudentMode(false)
    }
    const AddStudentHandler = () => {
        setEditStudent(undefined)
        setVisibleModal(true)
        setAddStudentMode(true)
    }

    useEffect(() => {
        getStudents().then(i => i)
    }, []);
    return <div>{
        visibleModal ? <Modal visibleModal={visibleModal} setVisibleModal={setVisibleModal} title={addStudentMode ? "Add New Student" : "Edit Student"}>
            {addStudentMode ? (
                <AddStudentForm storeStudent={storeStudent} student={undefined} />
            ) : (
                    <StudentForm storeStudent={storeStudent} student={editStudent} />
            )}
        </Modal> : null
    }
        <div className="text-3xl">Studentai</div>
        <button type="button" onClick={AddStudentHandler} className="bg-blue-500 text-white py-2 px-4 rounded nb-4">Add Student</button>
        <div>{
            students.map(student => <div key={student.id}>
                <button type="button" onClick={() => editHandler(student)}>{student.firstName} {student.lastName}</button>
                {student.email}</div>)
        }</div>
    </div>
}