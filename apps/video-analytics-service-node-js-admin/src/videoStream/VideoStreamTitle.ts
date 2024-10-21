import { VideoStream as TVideoStream } from "../api/videoStream/VideoStream";

export const VIDEOSTREAM_TITLE_FIELD = "id";

export const VideoStreamTitle = (record: TVideoStream): string => {
  return record.id?.toString() || String(record.id);
};
