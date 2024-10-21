import { Camera as TCamera } from "../api/camera/Camera";

export const CAMERA_TITLE_FIELD = "id";

export const CameraTitle = (record: TCamera): string => {
  return record.id?.toString() || String(record.id);
};
