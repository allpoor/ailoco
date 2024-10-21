import { DetectedObject as TDetectedObject } from "../api/detectedObject/DetectedObject";

export const DETECTEDOBJECT_TITLE_FIELD = "id";

export const DetectedObjectTitle = (record: TDetectedObject): string => {
  return record.id?.toString() || String(record.id);
};
