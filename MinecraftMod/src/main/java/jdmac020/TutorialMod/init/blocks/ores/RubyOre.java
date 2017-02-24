package jdmac020.TutorialMod.init.blocks.ores;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.ItemBlock;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class RubyOre extends TutorialOre
{
	public RubyOre()
	{
		setRegistryName("ruby_ore");
		setUnlocalizedName("ruby_ore");
		setHarvestLevel("pickaxe",3);
		setHardness(3.0F);
		setResistance(13F);
		setCreativeTab(TutorialTabs.tabTutorialBlocks);
	}
	
	
}
