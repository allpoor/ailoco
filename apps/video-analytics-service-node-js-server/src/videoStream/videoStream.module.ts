import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { VideoStreamModuleBase } from "./base/videoStream.module.base";
import { VideoStreamService } from "./videoStream.service";
import { VideoStreamController } from "./videoStream.controller";
import { VideoStreamResolver } from "./videoStream.resolver";

@Module({
  imports: [VideoStreamModuleBase, forwardRef(() => AuthModule)],
  controllers: [VideoStreamController],
  providers: [VideoStreamService, VideoStreamResolver],
  exports: [VideoStreamService],
})
export class VideoStreamModule {}
