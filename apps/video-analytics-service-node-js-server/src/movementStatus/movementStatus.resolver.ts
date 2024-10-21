import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { MovementStatusResolverBase } from "./base/movementStatus.resolver.base";
import { MovementStatus } from "./base/MovementStatus";
import { MovementStatusService } from "./movementStatus.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => MovementStatus)
export class MovementStatusResolver extends MovementStatusResolverBase {
  constructor(
    protected readonly service: MovementStatusService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
