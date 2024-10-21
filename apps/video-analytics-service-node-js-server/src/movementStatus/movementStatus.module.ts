import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { MovementStatusModuleBase } from "./base/movementStatus.module.base";
import { MovementStatusService } from "./movementStatus.service";
import { MovementStatusController } from "./movementStatus.controller";
import { MovementStatusResolver } from "./movementStatus.resolver";

@Module({
  imports: [MovementStatusModuleBase, forwardRef(() => AuthModule)],
  controllers: [MovementStatusController],
  providers: [MovementStatusService, MovementStatusResolver],
  exports: [MovementStatusService],
})
export class MovementStatusModule {}
