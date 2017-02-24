package jdmac020.TutorialMod.init;

import net.minecraft.item.Item.ToolMaterial;
import net.minecraftforge.common.util.EnumHelper;

public class TutorialMaterials 
{
	//harvest level like diamond, durability just less than diamond, mining speed faster than diamond,
	//damage a lil higher than diamond, enchants like wood
	public static ToolMaterial RUBY = EnumHelper.addToolMaterial("ruby", 3, 1200, 9.0F, 3.5F, 15);
	
	//harvest level like stone (no diamond, etc), durability not-quite-double iron, mining speed 1 less than iron
	//damage like iron, enchants 4 less than gold
	public static ToolMaterial COPPER = EnumHelper.addToolMaterial("copper", 1, 400, 5.0F, 2.0F, 18);
	
	
}
