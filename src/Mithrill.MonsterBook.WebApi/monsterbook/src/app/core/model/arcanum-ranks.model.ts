import { Arcanum } from "./arcanum.model";


export interface ArcanumRanks {
  primary: Arcanum;
  secondary: Arcanum;
  tertiary: Arcanum[];
  quaternary: Arcanum;
  quinary: Arcanum;
}
