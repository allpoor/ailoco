import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { CameraList } from "./camera/CameraList";
import { CameraCreate } from "./camera/CameraCreate";
import { CameraEdit } from "./camera/CameraEdit";
import { CameraShow } from "./camera/CameraShow";
import { VideoStreamList } from "./videoStream/VideoStreamList";
import { VideoStreamCreate } from "./videoStream/VideoStreamCreate";
import { VideoStreamEdit } from "./videoStream/VideoStreamEdit";
import { VideoStreamShow } from "./videoStream/VideoStreamShow";
import { DetectedObjectList } from "./detectedObject/DetectedObjectList";
import { DetectedObjectCreate } from "./detectedObject/DetectedObjectCreate";
import { DetectedObjectEdit } from "./detectedObject/DetectedObjectEdit";
import { DetectedObjectShow } from "./detectedObject/DetectedObjectShow";
import { TextDetectionList } from "./textDetection/TextDetectionList";
import { TextDetectionCreate } from "./textDetection/TextDetectionCreate";
import { TextDetectionEdit } from "./textDetection/TextDetectionEdit";
import { TextDetectionShow } from "./textDetection/TextDetectionShow";
import { MovementStatusList } from "./movementStatus/MovementStatusList";
import { MovementStatusCreate } from "./movementStatus/MovementStatusCreate";
import { MovementStatusEdit } from "./movementStatus/MovementStatusEdit";
import { MovementStatusShow } from "./movementStatus/MovementStatusShow";
import { UserList } from "./user/UserList";
import { UserCreate } from "./user/UserCreate";
import { UserEdit } from "./user/UserEdit";
import { UserShow } from "./user/UserShow";
import { httpAuthProvider } from "./auth-provider/ra-auth-http";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"VideoAnalyticsServiceNodeJs"}
        dataProvider={dataProvider}
        authProvider={httpAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="Camera"
          list={CameraList}
          edit={CameraEdit}
          create={CameraCreate}
          show={CameraShow}
        />
        <Resource
          name="VideoStream"
          list={VideoStreamList}
          edit={VideoStreamEdit}
          create={VideoStreamCreate}
          show={VideoStreamShow}
        />
        <Resource
          name="DetectedObject"
          list={DetectedObjectList}
          edit={DetectedObjectEdit}
          create={DetectedObjectCreate}
          show={DetectedObjectShow}
        />
        <Resource
          name="TextDetection"
          list={TextDetectionList}
          edit={TextDetectionEdit}
          create={TextDetectionCreate}
          show={TextDetectionShow}
        />
        <Resource
          name="MovementStatus"
          list={MovementStatusList}
          edit={MovementStatusEdit}
          create={MovementStatusCreate}
          show={MovementStatusShow}
        />
        <Resource
          name="User"
          list={UserList}
          edit={UserEdit}
          create={UserCreate}
          show={UserShow}
        />
      </Admin>
    </div>
  );
};

export default App;
