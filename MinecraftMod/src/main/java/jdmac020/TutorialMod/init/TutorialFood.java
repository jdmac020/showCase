package jdmac020.TutorialMod.init;

import jdmac020.TutorialMod.init.items.food.Butter;
import jdmac020.TutorialMod.main.Reference;
import jdmac020.TutorialMod.main.TutorialMod;
import net.minecraft.client.Minecraft;
import net.minecraft.client.renderer.block.model.ModelResourceLocation;
import net.minecraft.creativetab.CreativeTabs;
import net.minecraft.item.Item;
import net.minecraft.item.ItemFood;
import net.minecraft.util.ResourceLocation;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialFood 
{
	public static Item BUTTER;
	
	public static void init()
	{
		BUTTER = new Butter(1, .9F, false, "butter");
	}
	
	public static void register()
	{
		registerItem(BUTTER);
	}
	
	public static void registerItem(Item item)
	{
		GameRegistry.register(item);
		
		Minecraft.getMinecraft().getRenderItem().getItemModelMesher()
		.register(item, 0, new ModelResourceLocation(Reference.MODID + ":" + item.getUnlocalizedName().substring(5), "inventory"));
	}
	
}