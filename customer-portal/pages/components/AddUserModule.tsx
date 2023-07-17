import React, { useState } from "react";
import { Modal, Button, Text, Input, Row, Checkbox } from "@nextui-org/react";
import axios from "axios";
import ResuableButton from "./ReusableButton";

interface AddUserModuleProps {
    currentEntity: Entity | null;
    onSelectedEntity: (selectedEntity: Entity | null) => void;
    currentProject: Project | null;
    setCurrentProject: (currentProject: Project | null) => void;
    showAddUserModule: boolean;
    setShowAddUserModule: React.Dispatch<React.SetStateAction<boolean>>;
}

interface Project {
    projectName: string;
    projectId: string;
    entityId: string;
}

interface Entity {
    companyName: string;
    entityId: string;
}

export default function AddUserModule({
    currentEntity,
    onSelectedEntity,
    currentProject,
    setCurrentProject,
    showAddUserModule,
    setShowAddUserModule,
}: AddUserModuleProps) {
    const [email, setEmail] = useState("");

    console.log("current project in usermodule ", currentProject);
    console.log("current entity in usermodule ", currentEntity);

    const handler = () => setShowAddUserModule(true);
    const closeHandler = () => setShowAddUserModule(false);

    const handleAddEmailEntity = async () => {
        try {
            const emailUrl = "https://localhost:7243/api/emailentity";
            const emailEntitypayload = {
                Email: email,
                EntityId: `${currentEntity?.entityId}`,
            };

            const emailEntityresponse = await axios.post(
                emailUrl,
                emailEntitypayload
            );
            setEmail(email);
            // Handle the response data
            console.log(email);
            console.log(emailEntityresponse);

            const projectAppUserUrl = "https://localhost:7243/api/projectappuser";
            const ProjectAppUserpayload = {
                ProjectId: `${currentProject?.projectId}`,
                Email: email,
            };

            const projectAppUserresponse = await axios.post(
                projectAppUserUrl,
                ProjectAppUserpayload
            );

            console.log(email);
            console.log(projectAppUserresponse);
        } catch (error) {
            // Handle error
            console.error(error);
        }

        // Reset input field
        setEmail("");

        // Close the modal
        closeHandler();
    };

    // const handleAddProjectAppUser = async () => {
    //     try {
    //         const url = "https://localhost:7243/api/projectappuser";
    //         const projectAppUserpayload = {
    //             ProjectId: currentProject?.projectId,
    //             AppUserId: appUserId,
    //         };

    //         const response = await axios.post(url, projectAppUserpayload);

    //         // Handle the response data
    //         console.log(response.data);
    //     } catch (error) {
    //         // Handle error
    //         console.error(error);
    //     }
    // };

    const userStyle = {
        fontFamily: "Rasa",
        fontWeight: 600,
        fontSize: "18px",
        lineHeight: "40.8px",
        color: "#404040",
    };

    const userStyleInter = {
        ...userStyle,
        fontWeight: 400,
        fontSize: "24px",
    };

    const closeUserStyle = {
        ...userStyle,
        color: "#FF0000",
    };

    // const addUserStyle = {
    //     ...userStyle,
    // };

    const userNameStyle = {
        ...userStyle,
    };

    return (
        <div>
            <Button shadow onPress={handler} style={userStyle}>
                Add User
            </Button>
            <Modal
                closeButton
                aria-labelledby="modal-title"
                open={showAddUserModule}
                onClose={closeHandler}
            >
                <Modal.Header>
                    <Text id="modal-title" style={userStyleInter} size={18}>
                        Add User
                    </Text>
                </Modal.Header>
                <Modal.Body>
                    <Input
                        clearable
                        bordered
                        fullWidth
                        color="primary"
                        size="lg"
                        placeholder="Enter Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        style={userNameStyle}
                    />
                </Modal.Body>
                <Modal.Footer>
                    <Row justify="flex-end">
                        <Button style={closeUserStyle} onPress={closeHandler}>
                            Close
                        </Button>
                        <ResuableButton
                            style={{ color: "black" }}
                            onPress={handleAddEmailEntity}
                        >
                            Add User
                        </ResuableButton>
                    </Row>
                </Modal.Footer>
            </Modal>
        </div>
    );
}
